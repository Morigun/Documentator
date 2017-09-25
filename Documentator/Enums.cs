/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 10.09.2015
 * Время: 9:57
 */
using System;

namespace Documentator
{
	/// <summary>
	/// Description of Enums.
	/// </summary>
	public class Enums
	{
		public Enums()
		{
		}		
		public enum NodeToText{TypeElement, Name, Note, Event, Scene, NULL}		
		/// <summary>
		/// Возвращает значение ENUM, в значение строкой
		/// </summary>
		/// <param name="znach">Значение NodeToText</param>
		/// <returns>Значение строкой</returns>
		public string EnumToText(NodeToText znach)
		{
			switch(znach)
			{
				case NodeToText.TypeElement:
					return "Тип Элемента";
				case NodeToText.Note:
					return "Описание";
				case NodeToText.Event:
					return "Событие";
				case NodeToText.Scene:
					return "Сцена";
				case NodeToText.Name:
					return "Имя";
				default :
					return "EMPTY";
			}
		}
		/// <summary>
		/// По строке возвращает ENUM
		/// </summary>
		/// <param name="znach">Строка</param>
		/// <returns>Enum NodeToText</returns>
		public NodeToText TextToEnum(string znach)
		{
			switch(znach)
			{
				case "TypeElement":
					return NodeToText.TypeElement;
				case "Note":
					return NodeToText.Note;
				case "Event":
					return NodeToText.Event;
				case "Scene":
					return NodeToText.Scene;
				case "Name":
					return NodeToText.Name;
				default :
					return NodeToText.NULL;
			}
		}
		/// <summary>
		/// Список Атрибутов
		/// </summary>
		/// <param name="i">Номер атрибута</param>
		/// <returns>Enum аттрибута NodeToText</returns>
		public NodeToText IntToEnum(int i)
		{
			switch(i)
			{
				case 0:
					return NodeToText.Name;
				case 1:
					return NodeToText.TypeElement;
				default:
					return NodeToText.NULL;
			}
		}
	}
}
