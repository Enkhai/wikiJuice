using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ClassesForIndexer
{
    class LemmaMedia
    {
        private Lemma lemma;
        private List<Media> medias;

        public LemmaMedia(Lemma lemma, List<Media> medias)
        {
            this.lemma = lemma;
            this.medias = medias;
        }

        public Lemma GetLemma() { return lemma; }
        public List<Media> GetMedias() { return medias; }
    }
}
