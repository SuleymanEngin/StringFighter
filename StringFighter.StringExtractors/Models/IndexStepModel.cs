using System;
using System.Collections.Generic;
using System.Text;

namespace StringFighter.StringExtractors.Models
{
    public class IndexStepModel
    {
        public int Index { get; set; }

        public string Value { get; set; }

        public IndexStepModel NextStep { get; set; }
    }
}
