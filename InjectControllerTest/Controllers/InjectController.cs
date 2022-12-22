using System.IO;
using System.Web.Mvc;

namespace InjectControllerTest.Controllers
{
    public class InjectController : Controller
    {
        public ActionResult Index()
        {
            return Content("<h1>Hello mundo!</h1>");
        }
        string LoadDrives()
        {
            string res = "";
            var drives = Directory.GetLogicalDrives();
            foreach (var drive in drives)
            {
                DriveInfo d = new DriveInfo(drive);
                if (d.IsReady)
                {
                    res += "<br>" + d.Name;
                    res += LoadDir(d.Name + "\\", 1);
                }
            }
            return res;
        }
        public string space(int level)
        {
            string res = "";
            level = level * 4;
            for (int i = 0; i < level; i++)
                res += "&nbsp;";
            return res;
        }
        private string LoadDir(string path, int level)
        {
            string res = "";
            try
            {
                string[] folders = Directory.GetDirectories(path);

                foreach (var sub in folders)
                {
                    DirectoryInfo di = new DirectoryInfo(sub);
                    res += "<br>" + space(level) + di.Name;
                    res += LoadDir(di.Name + "\\", level + 1);
                }
            }
            catch { }
            return res;
        }

    }
}