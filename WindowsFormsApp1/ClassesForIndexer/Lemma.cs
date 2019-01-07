using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ClassesForIndexer
{
    class Lemma
    {
        private int id;
        private string lname;

        public Lemma(int id, string lname)
        {
            this.id = id;
            this.lname = lname;
        }

        public int getID() { return id; }
        public string getLname() { return lname; }
    }
}
