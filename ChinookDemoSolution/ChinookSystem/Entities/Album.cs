using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Entities
{
    [Table("Albums")]
    internal class Album
    {
        private string _ReleaseLabel;
        private int _ReleaseYear;

        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Album Title is Required")]
        [StringLength(160, ErrorMessage = "Album title is limited to 160 characters.")]
        public string Title { get; set; }

        public string ArtistId { get; set; }
        public int ReleaseYear 
        {
            get { return _ReleaseYear; }
            set {
                if (_ReleaseYear < 1950 || _ReleaseYear > DateTime.Today.Year)
                {
                    throw new Exception("Album release year is before 1950 or a year in the future");
                }
                else
                {
                    _ReleaseYear = value;
                }
            }
        }

        [Required(ErrorMessage = "Album release label Title is Required")]
        [StringLength(50, ErrorMessage = "Album release label is limited to 50 characters.")]
        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set { _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value; }
        }

        public int Miliseconds { get; set; }

        public int Bytes { get; set; }

        public double UnitPrice { get; set; }
    }
}
