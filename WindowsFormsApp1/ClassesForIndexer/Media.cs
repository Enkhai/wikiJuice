using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ClassesForIndexer
{
    class Media
    {
        private int id;
        private string data_type;
        private string content;

        public Media(int id, string data_type, string content)
        {
            this.id = id;
            this.data_type = data_type;
            this.content = content;
        }

        public int getId() { return id; }
        public string getDataType() { return data_type; }
        public string getContent() { return content; }
    }
}
