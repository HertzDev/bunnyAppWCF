using bunnyWCF.Controllers;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace bunnyWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Bunny : IBunny
    {

        public MaterialProductServiceEntity OnGetMaterialsProduct()
        {
            return MaterialProductController.Instance.OnGetMaterialsProduct();
        }

        public MessageHelper OnSetMaterialsProduct(MaterialProductEntity Material)
        {
            return MaterialProductController.Instance.OnSetMaterialProduct(Material);
        }


        public MaterialProductServiceEntity OnGetMaterialsProductByWord(string WordSearch)
        {
            return MaterialProductController.Instance.OnGetMaterialsProductByWord(WordSearch);
        }


        public MessageHelper OnDeleteMaterialsProduct(int Id)
        {
            return MaterialProductController.Instance.OnDeleteMaterialProduct(Id);
        }


        public StateServiceEntity OnGetStates()
        {
            return StateController.Instance.OnGetStates();
        }
        public StateServiceEntity OnGetStatesByWord(string WordSearch)
        {
            return StateController.Instance.OnGetStatesByWord(WordSearch);
        }
        public MessageHelper OnSetState(StateEntity State)
        {
            return StateController.Instance.OnSetState(State);
        }

        public MessageHelper OnDeleteState(int Id)
        {
            return StateController.Instance.OnDeleteState(Id);
        }


        public TypeUserServiceEntity OnGetTypesUser() 
        {
            return TypeUserController.Instance.OnGetTypesUser();
        }

        public TypeUserServiceEntity OnGetTypesUserByWord(string WordSearch)
        {
            return TypeUserController.Instance.OnGetTypesUserByWord(WordSearch);
        }

        public TypeUserServiceEntity OnGetTypesUserActives()
        {
            return TypeUserController.Instance.OnGetTypesUserActives();
        }

        public MessageHelper OnSetTypeUser(TypeUserEntity TypeUser)
        {
            return TypeUserController.Instance.OnSetTypeUser(TypeUser);
        }

        public MessageHelper OnDeleteTypeUser(int Id)
        {
            return TypeUserController.Instance.OnDeleteTypeUser(Id);
        }

        public TypeProductServiceEntity OnGetTypesProduct()
        {
            return TypeProductController.Instance.OnGetTypesProduct();
        }

        public TypeProductServiceEntity OnGetTypesProductByWord(string WordSearch)
        {
            return TypeProductController.Instance.OnGetTypesProductByWord(WordSearch);
        }

        public TypeProductServiceEntity OnGetTypesProductActives()
        {
            return TypeProductController.Instance.OnGetTypesProductActives();
        }

        public MessageHelper OnSetTypeProduct(TypeProductEntity TypeProduct)
        {
            return TypeProductController.Instance.OnSetTypeProduct(TypeProduct);
        }

        public MessageHelper OnDeleteTypeUser(int Id)
        {
            return TypeProductController.Instance.OnDeleteTypeProduct(Id);
        }

    }
}
