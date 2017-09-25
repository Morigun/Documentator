/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/08/2015
 * Время: 18:29
 */
using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Documentator
{
	/// <summary>
	/// Description of OpenDocumentationFromXml.
	/// </summary>
	public class OpenDocumentationFromXml
	{
		public OpenDocumentationFromXml()
		{
		}
		//Путь к XML
		string _path, _tmpName;
		List<string> _attrs;
		//XML реадер/для парсинга
		XmlTextReader _reader;	
		ParsTypeElement _pte;		
		Dictionary<Enums.NodeToText, string> _tagValue;
		Enums _func;
		/// <summary>
		/// Конструктор 
		/// </summary>
		/// <param name="PathToXml">Пусть к XML файлу</param>
		public OpenDocumentationFromXml(string PathToXml)
		{
			this._attrs = new List<string>();
			this._path = PathToXml;
			this._reader = new XmlTextReader(this._path);
			this._pte = new ParsTypeElement();
			this._tagValue = new Dictionary<Enums.NodeToText, string>();
			this._func = new Enums();
		}
		/// <summary>
		/// Парсит XML и возвращает строку
		/// </summary>
		/// <returns>Текс XML в читабельном виде Х)</returns>
		public string GetAllNodes()
		{
			string AllText = String.Empty;
			this._tagValue.Clear();			
			WriteData(this._reader);		
			AllText = WriteFromDictionary();
			return AllText;
		}
		/// <summary>
		/// Печать тэгов в текст
		/// </summary>
		/// <returns>Возвращает текст</returns>
		string WriteFromDictionary()
		{
			string AllText = String.Empty;
			foreach(Enums.NodeToText en in this._tagValue.Keys.OrderBy(x => x))
			{				
				AllText = String.Format("{2} {0} {1} \r\n",this._func.EnumToText(en), this._tagValue[en],AllText);
			}
			return AllText;
		}
		/// <summary>
		/// Запись в Dictionary TagValue
		/// </summary>
		/// <param name="_xmlNodeType">Текущий тип узла</param>
		/// <param name="_reader">XmlTextReader по которому идет чтение</param>
		public void WriteData(XmlTextReader _reader)
		{			
			while(this._reader.Read())
			{				
				for(int x = 0; x < _reader.AttributeCount; x++)
				{
					if (_reader.HasAttributes && _reader.Name != "xml")
						_attrs.Add(_reader.GetAttribute(x));
				}
				if(_reader.NodeType == XmlNodeType.Element)
				{
					if (this._func.EnumToText(this._func.TextToEnum(_reader.Name)) != "EMPTY" )
					{
						this._tagValue.Add(this._func.TextToEnum(_reader.Name),"");
						_tmpName = _reader.Name;
					}
				}
				else if(_reader.NodeType == XmlNodeType.Text)
				{
					for(int s = 0; s <_attrs.Count; s++)
					{
						this._tagValue.Add(this._func.IntToEnum(s),_attrs[s]);
					}
					_attrs.Clear();
					this._tagValue[this._func.TextToEnum(_tmpName)] = _reader.Value;
					_tmpName = null;
				}
			}
		}
	}
}
