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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IBunny
    {
        /*Material Product*/
        [OperationContract, WebGet(UriTemplate = "MaterialProduct", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MaterialProductServiceEntity OnGetMaterialsProduct();

        [OperationContract, WebInvoke(UriTemplate = "MaterialProduct",Method="POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MessageHelper OnSetMaterialsProduct(MaterialProductEntity Material);

        [OperationContract, WebGet(UriTemplate = "MaterialProduct/{WordSearch}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MaterialProductServiceEntity OnGetMaterialsProductByWord(string WordSearch);

        [OperationContract, WebInvoke(UriTemplate = "MaterialProductD", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MessageHelper OnDeleteMaterialsProduct(int Id);

        /*States*/
        [OperationContract, WebGet(UriTemplate = "States", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StateServiceEntity OnGetStates();

        [OperationContract, WebGet(UriTemplate = "States/{WordSearch}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StateServiceEntity OnGetStatesByWord(string WordSearch);

        [OperationContract, WebInvoke(UriTemplate = "State", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MessageHelper OnSetState(StateEntity State);
        [OperationContract, WebInvoke(UriTemplate = "StateD", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MessageHelper OnDeleteState(int Id);

        /*TypeUser*/
        [OperationContract, WebGet(UriTemplate = "TypeUser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StateServiceEntity OnGetTypesUser();
        [OperationContract, WebGet(UriTemplate = "TypeUser/{WordSearch}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StateServiceEntity OnGetTypesUserByWord(string WordSearch);
        [OperationContract, WebGet(UriTemplate = "TypeUserA", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StateServiceEntity OnGetTypesUserActives();
        [OperationContract, WebInvoke(UriTemplate = "TypeUser", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MessageHelper OnSetTypeUser(TypeUserEntity TypeUser);
        [OperationContract, WebInvoke(UriTemplate = "TypeUserD", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MessageHelper OnDeleteTypeUser(int Id);

        /*TypeProduct*/
        [OperationContract, WebGet(UriTemplate = "TypeProduct", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StateServiceEntity OnGetTypesProduct();
        [OperationContract, WebGet(UriTemplate = "TypeProduct/{WordSearch}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StateServiceEntity OnGetTypesProductByWord(string WordSearch);
        [OperationContract, WebGet(UriTemplate = "TypeProductA", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        StateServiceEntity OnGetTypesProductActives();
        [OperationContract, WebInvoke(UriTemplate = "TypeProduct", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MessageHelper OnSetTypeProduct(TypeProductEntity TypeProduct);
        [OperationContract, WebInvoke(UriTemplate = "TypeProductD", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MessageHelper OnDeleteTypeProduct(int Id);

    }
}
