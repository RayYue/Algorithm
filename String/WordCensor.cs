using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.Example.Algorithm.String
{
    /// <summary>
    /// 敏感词树
    /// </summary>
    public class WordCensorNode
    {
        public Dictionary<char, WordCensorNode> Child;
        public bool IsEnd;
    }


    /// <summary>
    /// 自定义过滤方法
    /// </summary>
    /// <param name="text">找到的字符串</param>
    /// <param name="offset">起始位置</param>
    /// <param name="length">字符串长度</param>
    /// <returns>替换后的</returns>
    public delegate string ReplaceDelegate(string text, int offset, int length);

    public class WordCensor
    {
        private static readonly object lockObj = new object();
        /// <summary>
        /// 根节点
        /// </summary>
        private static WordCensorNode _root;
        private const string TraditionalChinese = "";
        private const string SimplifiedChinese = "";
        private static readonly Dictionary<char, char> TranslationChinese = TraditionalChinese.Select((c, i) => new { c, i }).ToDictionary(p => p.c, p => SimplifiedChinese[p.i]);

        /// <summary>
        /// 初始化 使用前必须调用一次
        /// </summary>
        /// <param name="keyWords">敏感词列表</param>
        public static void Init(string[] keyWords)
        {
            if (_root != null) return;
            lock (lockObj)
            {
                _root = new WordCensorNode();
                var list = keyWords.Select(p => new string(Translation(p))).Distinct().OrderBy(p => p).ThenBy(p => p.Length).ToList();
                for (int i = list.Min(p => p.Length); i <= list.Max(p => p.Length); i++)
                {
                    int i1 = i;
                    var startList = list.Where(p => p.Length >= i1).Select(p => p.Substring(0, i1)).Distinct();
                    foreach (var startWord in startList)
                    {
                        var tmp = _root;
                        for (int j = 0; j < startWord.Length; j++)
                        {
                            var t = startWord[j];
                            if (tmp.Child == null)
                                tmp.Child = new Dictionary<char, WordCensorNode>();

                            if (!tmp.Child.ContainsKey(t))
                            {
                                tmp.Child.Add(t, new WordCensorNode { IsEnd = list.Contains(startWord.Substring(0, 1 + j)) });
                            }

                            tmp = tmp.Child[t];
                        }
                    }
                }

            }
        }

        /// <summary>
        /// 查找含有的关键词
        /// </summary>
        public static bool Find(string text, out string[] keyWords)
        {

            keyWords = Find(text).Select(p => text.Substring(p.Key, p.Value)).Distinct().ToArray();
            return keyWords.Length > 0;
        }

        /// <summary>
        /// 简单快速替换
        /// </summary>
        public static string Replace(string text)
        {
            var dic = Find(text);
            var list = text.ToArray();
            foreach (var i in dic)
            {
                for (int j = i.Key; j < i.Key + i.Value; j++)
                {
                    list[j] = '*';
                }
            }
            return new string(list.ToArray());
        }

        /// <summary>
        /// 自定义过滤
        /// </summary>
        public static string Replace(string text, ReplaceDelegate replaceAction)
        {

            var dic = Find(text);
            var list = text.ToList();
            var offset = 0;
            foreach (var i in dic)
            {

                list.RemoveRange(i.Key + offset, i.Value);
                var newText = replaceAction(text.Substring(i.Key, i.Value), i.Key, i.Value);
                list.InsertRange(i.Key + offset, newText);

                offset = offset + newText.Length - i.Value;
            }
            return new string(list.ToArray());
        }


        /// <summary>
        /// 位置查找
        /// </summary>
        private static Dictionary<int, int> Find(string src)
        {
            if (_root == null)
                throw new InvalidOperationException("未初始化");

            var findResult = new Dictionary<int, int>();
            if (string.IsNullOrEmpty(src))
                return findResult;


            var text = Translation(src);
            int start = 0;

            while (start < text.Length)
            {
                int length = 0;
                var firstChar = text[start + length];
                var node = _root;

                //跳过特殊符号
                while (IsSkip(firstChar) && (start + length + 1) < text.Length)
                {
                    start++;
                    firstChar = text[start + length];
                }

                //不匹配首字符 移动起始位置
                while (!node.Child.ContainsKey(firstChar) && start < text.Length - 1)
                {
                    start++;
                    firstChar = text[start + length];
                }

                //部分匹配 移动结束位置 直到不匹配
                while (node.Child != null && node.Child.ContainsKey(firstChar))
                {
                    node = node.Child[firstChar];
                    length++;

                    if ((start + length) == text.Length)
                        break;

                    firstChar = text[start + length];

                    //跳过忽略词
                    while (IsSkip(firstChar) && !node.IsEnd && (start + length + 1) < text.Length)
                    {
                        length++;
                        firstChar = text[start + length];
                    }
                }

                //完整匹配 把起始位置移到结束位置
                if (node.IsEnd)
                {
                    findResult.Add(start, length);
                    start += length - 1;
                }

                start++;
            }
            return findResult;
        }


        /// <summary>
        /// 字符串预处理
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private static char[] Translation(string src)
        {
            char[] c = src.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                /*全角=>半角*/
                if (c[i] > 0xFF00 && c[i] < 0xFF5F)
                    c[i] = (char)(c[i] - 0xFEE0);

                /*大写=>小写*/
                if (c[i] > 0x40 && c[i] < 0x5b)
                    c[i] = (char)(c[i] + 0x20);

                /*繁体=>简体*/
                if (c[i] > 0x4E00 && c[i] < 0x9FFF)
                {
                    char chinese;
                    if (TranslationChinese.TryGetValue(c[i], out chinese))
                        c[i] = chinese;
                }
            }
            return c;
        }

        /// <summary>
        /// 跳过特殊符号 ASCII范围 排除 数字字母
        /// </summary>
        private static bool IsSkip(char firstChar)
        {
            if (firstChar < '0')
                return true;
            if (firstChar > '9' && firstChar < 'A')
                return true;
            if (firstChar > 'Z' && firstChar < 'a')
                return true;
            if (firstChar > 'z' && firstChar < 128)
                return true;
            return false;
        }
    }
}