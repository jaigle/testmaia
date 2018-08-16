using DLMallas.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business
{
    public class Menu
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<DtoPagina> getSideMenu(int idSociedad, string userName,string pagina)
        {
            return new List<DtoPagina>();
            //var menusvc = new SvcSecurity.SecurityClient();
            try { 
               // return menusvc.GetSideMenu(idSociedad, userName, pagina).ToList();
            }catch(Exception ex){
                return new List<DtoPagina>();
            }
            
        }
        public List<Node<DtoPagina>> ObtenerMenu(string idSociedad, string userName)
        {
            try
            {
                var seguridadSvc = new Seguridad();
                var menus = seguridadSvc.ObtenerMenu(idSociedad, userName);

                var nodeList = new List<Node<DtoPagina>>();

                foreach (var menu in menus.Where(m => m.IdPadre == "0"))
                {
                    var node = ToNode(menu, menus);

                    nodeList.Add(node);

                    // ordenar por "orden"
                    node.Children = node.Children.OrderBy(n => n.Value.Orden).ToList();
                }
                logger.Debug("MENU OK");
                return nodeList;
            }
            catch (Exception ex)
            {
                logger.Error("Se arrojó una excepción al obtener el MENU: ", ex);
                return new List<Node<DtoPagina>>();
            }
        }

        private Node<DtoPagina> ToNode(DtoPagina menu, IEnumerable<DtoPagina> menus)
        {
            var node = new Node<DtoPagina>();
            node.Value = menu;

            foreach (var child in menus.Where(m => m.IdPadre == menu.Id))
            {
                var childNode = ToNode(child, menus);

                node.Children.Add(childNode);
            }

            // ordenar por "orden"
            node.Children = node.Children.OrderBy(n => n.Value.Orden).ToList();

            return node;
        }


    }
  
    public class Node<T>
    {
        public T Value { get; set; }

        public IList<Node<T>> Children { get; set; }

        public bool HasChildren
        {
            get { return Children.Any(); }
        }

        public Node()
        {
            Children = new List<Node<T>>();
        }
    }
}
