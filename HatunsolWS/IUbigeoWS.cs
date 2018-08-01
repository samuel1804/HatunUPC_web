﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HatunsolBE;
namespace HatunsolWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUbigeoWS" in both code and config file together.
    [ServiceContract]
    public interface IUbigeoWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "Ubigeo", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<UbigeoBE> Listar();
    }
}
