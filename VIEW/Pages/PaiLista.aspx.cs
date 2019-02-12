using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace VIEW.Pages
{

    public partial class PaiLista : System.Web.UI.Page
    {
        protected void btnPesquisarNome(object sender, EventArgs e){
            string nomePai = nome.Text;
            PaiDal paiDal = new PaiDal();

            gridListaPai.DataSource = paiDal.PesquisarPorNome(nomePai);
            gridListaPai.DataBind();
        }
    }
}
