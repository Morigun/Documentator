/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/07/2015
 * Время: 14:17
 */
using System;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Documentator
{
	/// <summary>
	/// Description of DocumentationXml.
	/// </summary>
	public class DocumentationXml
	{		
		public DocumentationXml(string _path, List<ElementTypes> _et, List<TypeElements> _telm)
		{			
			this.PathToXml = _path;
			this._doc = new XmlDocument();
			et = _et;
			TypeElem = _telm;
			CreateNewXml();
			InsertDataInXml();
		}
		/// <summary>
		/// Создаем файл с корневым узлом Documentation
		/// </summary>
		void CreateNewXml()
		{
			this._writer = new  XmlTextWriter(this.PathToXml, Encoding.UTF8);
			_writer.WriteStartDocument();
			_writer.WriteStartElement("Documentation");
			_writer.WriteEndElement();
			_writer.Close();
		}		
		/// <summary>
		/// Вносим данные в файл по пути
		/// </summary>
		void InsertDataInXml()
		{
			//Грузим файл по пути
			_doc.Load(this.PathToXml);
			
			foreach(TypeElements e in this.TypeElem)
			{				
				XmlNode el = _doc.CreateElement(e.Name);
				_doc.DocumentElement.AppendChild(el);
				foreach(ElementTypes ee in this.et)
				{
					if (ee.TypeEl.Name == e.Name)
					{
						XmlNode subEl = _doc.CreateElement(ee.El);
						el.AppendChild(subEl);
						
						XmlAttribute _nameElelmentAttribut = _doc.CreateAttribute("Name");
						_nameElelmentAttribut.Value = ee.Name;
						subEl.Attributes.Append(_nameElelmentAttribut);
						
						XmlAttribute _typeElementAttribut = _doc.CreateAttribute("TypeElement");
						_typeElementAttribut.Value = subEl.Name;
						subEl.Attributes.Append(_typeElementAttribut);
						
						XmlNode subSubElText = _doc.CreateElement("Note");
						subSubElText.InnerText = ee.Note;
						subEl.AppendChild(subSubElText);
						
						XmlNode subSubElEvent = _doc.CreateElement("Event");
						subSubElEvent.InnerText = ee.EventText;
						subEl.AppendChild(subSubElEvent);	

						XmlNode subSubElScene = _doc.CreateElement("Scene");
						subSubElScene.InnerText = ee.NameScene;
						subEl.AppendChild(subSubElScene);	
					}
				}
			}			
			
			//Сохраняем изменения
			_doc.Save(this.PathToXml);
		}
		/// <summary>
		/// Пример заполнения данных
		/// </summary>
		void InsertDataInXmlExample()
		{
			//Грузим файл по пути
			_doc.Load(this.PathToXml);
			//Создаем элемент, под элемент файла
			XmlNode el = _doc.CreateElement("El");
			//Добавляем созданный элемент в иерархию файла
			_doc.DocumentElement.AppendChild(el);
			//Создаем атрибут
			XmlAttribute attr = _doc.CreateAttribute("number");
			//Вписываем атрибуту значение
			attr.Value = "1";
			//Добавляем атрибут к созданному элементу
			el.Attributes.Append(attr);
			
			//Добавляем новый элемент
			XmlNode subEl1 = _doc.CreateElement("subEl1");
			//Вписываем его значение
			subEl1.InnerText = "Hello";
			//Добавляем его к вышесозданному элементу
			el.AppendChild(subEl1);
			
			XmlNode subEl2 = _doc.CreateElement("subEl2");
			subEl2.InnerText = "Dear";
			el.AppendChild(subEl2);
			
			XmlNode subEl3 = _doc.CreateElement("subEl3");
			subEl3.InnerText = "World";
			el.AppendChild(subEl3);
			
			//Сохраняем изменения
			_doc.Save(this.PathToXml);
		}
		
		public string PathToXml;
		XmlTextWriter _writer;
		XmlDocument _doc;
		List<ElementTypes> et;
		List<TypeElements> TypeElem;
	}
}
