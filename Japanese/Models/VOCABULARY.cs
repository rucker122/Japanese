using System;
using System.ComponentModel.DataAnnotations;

namespace Japanese.Models
{
    public class VOCABULARY
    {
        public int id { get; set; }

        [Display(Name = "詞性")]
        public int speech { get; set; }

        [Display(Name = "類型")]
        public int? type { get; set; }

        [Display(Name = "單字")]
        public string vocabulary { get; set; }

        [Display(Name = "漢字")]
        public string kanji { get; set; }

        [Display(Name = "中文")]
        public string chinese { get; set; }

        [Display(Name = "備註")]
        public string remark { get; set; }

        [Display(Name = "標籤")]
        public string tags { get; set; }


        [Display(Name = "建立日期")]
        public DateTime create_date { get; set; }
        [Display(Name = "修改日期")]
        public DateTime? modify_date { get; set; }
    }
}
