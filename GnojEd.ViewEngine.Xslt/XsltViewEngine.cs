namespace GnojEd.ViewEngine.Xslt {
  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using System.IO;
  using System.Text.RegularExpressions;
  using System.Web;
  using System.Xml;
  using System.Xml.Linq;
  using System.Xml.Serialization;
  using System.Xml.Xsl;
  using Jessica.ViewEngine;

  /// <summary>
  /// XsltViewEngine class
  /// </summary>
  public class XsltViewEngine : IViewEngine {
    /// <summary>Transformer object</summary>
    private XslCompiledTransform xslt = new XslCompiledTransform();

    /// <summary>
    /// Gets the list of extensions used 
    /// </summary>
    public IEnumerable<string> Extensions {
      get {
        return new[] { "xsl", "xslt" };
      }
    }

    /// <summary>
    /// RenderView method
    /// </summary>
    /// <param name="viewLocation">ViewLocation object</param>
    /// <param name="model">dynamic model object</param>
    /// <returns>Action object</returns>
    public Action<Stream> RenderView(ViewLocation viewLocation, dynamic model) {
      return stream => {
        XmlDocument xmlModel = new XmlDocument();

        SortedList<string, string> props = new SortedList<string, string>();
        this.AddProps(HttpContext.Current.Request.Params, props);

        var xmlString = String.Empty;
        if (model != null) {
          xmlString = String.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?><data><Model>{0}</Model>{1}</data>", this.Serialize(model), this.GetPropsAsXml(props));
        }
        else {
          xmlString = String.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?><data><Model><null /></Model>{0}</data>", this.GetPropsAsXml(props));
        }

        xmlModel.LoadXml(xmlString);

        xslt.Load(viewLocation.Location, XsltSettings.TrustedXslt, new XmlUrlResolver());

        var args = new XsltArgumentList();
        foreach (var prop in props) {
          if (!String.IsNullOrWhiteSpace(prop.Value)) {
            args.AddParam(prop.Key.ToLowerInvariant(), String.Empty, prop.Value);
          }
        }

        xslt.Transform(xmlModel, args, stream);
      };
    }

    /// <summary>
    /// GetPropsAsXml method
    /// </summary>
    /// <param name="props">SortedList with properties</param>
    /// <returns>XML representation of the list</returns>
    private string GetPropsAsXml(SortedList<string, string> props) {
      XElement root = new XElement("props");
      foreach (var prop in props) {
        if (!String.IsNullOrWhiteSpace(prop.Value)) {
          root.Add(new XElement("prop", new XAttribute("name", prop.Key.ToLowerInvariant()), new XAttribute("value", prop.Value)));
        }
      }

      return root.ToString(SaveOptions.DisableFormatting);
    }

    /// <summary>
    /// AddProps method
    /// </summary>
    /// <param name="nameValueCollection">NameValueCollection object</param>
    /// <param name="props">SortedList with properties</param>
    private void AddProps(NameValueCollection nameValueCollection, SortedList<string, string> props) {
      foreach (string key in nameValueCollection.AllKeys) {
        if (!String.IsNullOrWhiteSpace(key)) {
          props.Add(key, nameValueCollection[key]);
        }
      }
    }

    /// <summary>
    /// Serialize to XML method
    /// </summary>
    /// <param name="obj">Object object</param>
    /// <returns>String with XML</returns>
    private string Serialize(object obj) {
      XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
      ns.Add(String.Empty, String.Empty);
      XmlWriterSettings writerSettings = new XmlWriterSettings();
      writerSettings.OmitXmlDeclaration = true;

      XmlSerializer serializer = new XmlSerializer(obj.GetType());
      StringWriter stringWriter = new StringWriter();

      using (XmlWriter writer = XmlWriter.Create(stringWriter, writerSettings)) {
        serializer.Serialize(writer, obj, ns);
      }

      return stringWriter.ToString();
    }
  }
}
