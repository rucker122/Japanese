using System.ComponentModel.DataAnnotations;

namespace Japanese.Models
{
    public class SYLLABARIES
    {
        public int id { get; set; }

        [Display(Name = "類型")]
        public int type { get; set; }

        [Display(Name = "音行")]
        public int row { get; set; }

        [Display(Name = "音欄")]
        public int col { get; set; }

        [Display(Name = "發音")]
        public string pronounce { get; set; }

        [Display(Name = "假名")]
        public string character { get; set; }
    }
}
