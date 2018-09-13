using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hexaDECIMAL
{
    class articleClass
    {
        private int artid;
        private string artTitle;
        private string artText;
        private string artAuthor;
        private string artDate;


        public articleClass(string artTitle, string artText, string artAuthor, string artDate)
        {
            this.artTitle = artTitle;
            this.artText = artText;
            this.artAuthor = artAuthor;
            this.artDate = artDate;
        }       

        public string ArtTitle
        {
            get
            {
                return artTitle;
            }

            set
            {
                artTitle = value;
            }
        }

        public string ArtText
        {
            get
            {
                return artText;
            }

            set
            {
                artText = value;
            }
        }

        public string ArtAuthor
        {
            get
            {
                return artAuthor;
            }

            set
            {
                artAuthor = value;
            }
        }

        public string ArtDate
        {
            get
            {
                return artDate;
            }

            set
            {
                artDate = value;
            }
        }
    }
}
