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
    [Table("Tracks")]
    internal class track
    {
        private string _Name;
        private string _Composer;

        [Key]
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Track Name is Required")]
        [StringLength(120, ErrorMessage = "Track Name is limited to 120 characters.")]
        public string Name
        {
            get { return _Name; }
            set { _Name = string.IsNullOrEmpty(value) ? null : value; }
        }

        public int AlbumID { get; set; }

        public int MediaTypeId { get; set; }

        public int GenreId { get; set; }

        [StringLength(220, ErrorMessage = "Composer is limited to 220 characters.")]
        public string Composer
        {
            get { return _Composer; }
            set { _Composer = string.IsNullOrEmpty(value) ? null : value; }
        }


    }
}
