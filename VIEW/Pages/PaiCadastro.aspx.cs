using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace VIEW.Pages
{
    public partial class PaiCadastro : System.Web.UI.Page
    {
        protected void btnCadastrarPai(object sender, EventArgs e){
            try{
                Pai pai = new Pai();
                PaiDal paiDal = new PaiDal();

                pai.Nome = nome.Text;

                paiDal.Salvar(pai);
                Response.Redirect("/Pages/PaiCadastro.aspx");

            }catch(Exception erro){
                lblMensagem.Text = erro.ToString();
            } 
        }
    }
}
