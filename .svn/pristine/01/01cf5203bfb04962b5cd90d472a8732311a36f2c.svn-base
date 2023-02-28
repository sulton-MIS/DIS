using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AI070.Models.WP03004Master
{
    public class WP03004Master
    {
        public int ROW_NUM { get; set; }
        public string ID { get; set; }
        public string TITLE { get; set; }
        public string TRAINING_FOR { get; set; }
        public string DESCRIPTION { get; set; }
        public string CONTENT_TRAINING { get; set; }
        public string FILE_PATH { get; set; }
        public string FILE_NAME { get; set; }
        
        public Int16 IS_DELETED { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DT { get; set; }
    }

    public class TrainingDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Data Title Cannot be Empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Data Training For Cannot be Empty")]
        public string Training_for { get; set; }

        [Required(ErrorMessage = "Data Description Cannot be Empty")]
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public HttpPostedFileBase File { get; set; }

        [Required(ErrorMessage = "Data Content Cannot be Empty")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }

}