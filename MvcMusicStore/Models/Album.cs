using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{

    //[Bind(Exclude = "AlbumId")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        [DisplayName("Artist")]
        public int ArtistId { get; set; }
        [Required(ErrorMessage = "需要一个专辑标题!")]
        [StringLength(160)]
        public string Title { get; set; }
        [Required(ErrorMessage = "价格是必需的!")]
        [Range(0.01, 100.00,
        ErrorMessage = "价格必须在0.01至100.00之间!")]
        public decimal Price { get; set; }
        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
