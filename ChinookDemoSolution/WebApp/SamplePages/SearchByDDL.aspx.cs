using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion
namespace WebApp.SamplePages
{
    public partial class SearchByDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //this is first time 
                LoadArtistList();
            }
        }

        #region Error handling Methods for ODS
        protected void SelectCheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }

        #endregion

        protected void LoadArtistList()
        {
            ArtistController sysmgr = new ArtistController();
            List<SelectionList> info = sysmgr.Artists_DDL_List();

            //let's assume the data collection needs to be sorted
            info.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

            //setup the ddl 
            ArtistList.DataSource = info;
            ArtistList.DataTextField = nameof(SelectionList.DisplayField);
            ArtistList.DataValueField = nameof(SelectionList.ValueField);
            ArtistList.DataBind();

            //setup of prompt line
            ArtistList.Items.Insert(0, new ListItem("Select...", "0"));
        }

        protected void SearchAlbums_Click(object sender, EventArgs e)
        {
            if (ArtistList.SelectedIndex == 0)
            {
                //am I on the first line (prompt line) of the DDL
                MessageUserControl.ShowInfo("Title", "Please make an artist selection");
                ArtistAlbumsList.DataSource = null;
                ArtistAlbumsList.DataBind();
            }
            else
            {
                MessageUserControl.TryRun(()=>{
                    AlbumController sysmgr = new AlbumController();
                    List<ChinookSystem.ViewModels.ArtistAlbums> info = sysmgr.Albums_GetAlbumsForArtists(int.Parse(ArtistList.SelectedValue));
                    ArtistAlbumsList.DataSource = info;
                    ArtistAlbumsList.DataBind();
                },"Success tittle", "Success message");
                
            }
        }
    }
}