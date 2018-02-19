using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Banner
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PictureBig { get; set; }
        public string PictureSmall { get; set; }
    }
}
