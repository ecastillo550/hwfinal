using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaOperativo {
    public partial class state : Form {
        public state() {
            InitializeComponent();
        }

        private void state_Load(object sender, EventArgs e) {

        }

        public DataGridView statedgvINT {
            get { return statedgv; }
            set { statedgv = value; }
        }

        private void cls_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Hide();
        }
    }
}
