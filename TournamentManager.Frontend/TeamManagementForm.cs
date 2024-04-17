using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentManager.Backend;

namespace TournamentManager.Frontend
{
    public partial class TeamManagementForm : Form
    {
        private BackendMain Backend;
        public TeamManagementForm(BackendMain backend)
        {
            InitializeComponent();
            this.Backend = backend;
        }
    }
}
