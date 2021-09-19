using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolGood.Words;

namespace SY.Com.Infrastructure
{
    public static class KeyWordReplace
    {
        public const string KeyWords = "";

        /// <summary>
        /// 字符串替换
        /// </summary>
        /// <param name="str">需要替换的字符串</param>
        /// <returns></returns>
        public static string Replace(string str)
        {
            //StringSearch iwords = new StringSearch();
            //iwords.SetKeywords(KeyWords.Split('|'));

            IllegalWordsSearch iwords = new IllegalWordsSearch();
            iwords.SetKeywords(KeyWords.Split('|'));
            return iwords.Replace(str);
        }

        public static string GetPinYinBuild(string name)
        {
           return WordsHelper.GetFirstPinYin(name);
        }

    }
}
