using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageTrainApp.Models
{
    public class ImageTrainModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}