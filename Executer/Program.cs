using StringFighter.StringExtractors;
using StringFighter.StringExtractors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Executer
{
    class Program
    {
        static void Main(string[] args)
        {

            ChangingValuesExtractor changingValuesExtractor = new ChangingValuesExtractor("{} naber? {}'le görüştün mü? tam orospu cocugu ya o. {} denen ibneyle takılıyomus {}");

            var value = "cemalettin dal yarrak naber? ali'le görüştün mü? tam orospu cocugu ya o. kaşar ahmet denen ibneyle takılıyomus aksarayda";

            changingValuesExtractor.ExtractChangingValues(ref value);

        }

        public static void Testt(IndexStepModel indexStepModel)
        {
            indexStepModel.Value = "cemalettin";
        }
    }
}
