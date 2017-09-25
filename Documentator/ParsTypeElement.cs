/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/07/2015
 * Время: 10:12
 */
using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Documentator
{
	/// <summary>
	/// Description of ParsTypeElement.
	/// </summary>
	public class ParsTypeElement
	{
		public ParsTypeElement()
		{
			
		}
		XmlTextReader _reader;
		public List<string> PathsList;		
		public List<ElementTypes> ElementTypesList;
		string _tmpNamePath;
		/// <summary>
		/// Инициализация Элемента для разбора
		/// </summary>
		/// <param name="_path">Путь к xml файлу для дальнейшего его разбора</param>
		public ParsTypeElement(string _path)
		{
			this._reader = new XmlTextReader(_path);
			this.ElementTypesList = new List<ElementTypes>();			
			this.PathsList = new List<string>();
		}
		/// <summary>
		/// Чтение узлов и заполнение структуры ElementTypesList = List ElementTypes
		/// </summary>
		public void ReadNodes()
		{
			while(this._reader.Read())
			{
				switch(this._reader.NodeType)
				{
					case XmlNodeType.Element :
						this._tmpNamePath = this._reader.Name;
						if (this._reader.Name != "Element")
						{
							this.PathsList.Add(this._tmpNamePath);
						}
						break;
					case XmlNodeType.Text :
						this.ElementTypesList.Add(new ElementTypes(this._reader.Value, this.PathsList[this.PathsList.Count-1]));
						this._tmpNamePath = string.Empty;
						break;
					case XmlNodeType.EndElement :						
						break;
					default :
							//throw new Exception("Не найден узел");
						break;
				}
			}
		}	
	}
}
