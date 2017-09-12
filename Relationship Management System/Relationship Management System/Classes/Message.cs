﻿using Relationship_Management_System.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Classes {
	public class Message {
		private string HTML;
		private List<Interest> Interests = new List<Interest>();

		public Message(string HTML, List<Interest> Interests) {
			this.HTML = HTML.ToLower();
			this.Interests = Interests;
		}

		public string GetResponse() {
			var SourceText = ExtractText(HTML.ToLower());
			var Matches = new List<Interest>();
			foreach (var item in Interests) {
				if (SourceText.Contains(" " + item.Name.ToLower()) || SourceText.Contains(item.Name.ToLower() + " ")) {
					Matches.Add(item);
				}
			}

			string Responce;
			Responce = "Hello, I'm Aaron";

			if (Matches.Any()) {
				foreach (var item in Matches) {
					Responce += "\r\n" + item.Message;
				}
			}
			else {
				Responce += "\r\nAdd something about profile in here";
			}

			//TODO: Add Hangout spots
			Responce += "\r\n\r\nAre you interested in meeting me for coffee or perhaps a bite to eat somewhere?";

			return Responce;
		}

		private static string ExtractText(string html) {
			if (html == null) {
				throw new ArgumentNullException("html");
			}

			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(html);

			var chunks = new List<string>();

			foreach (var item in doc.DocumentNode.DescendantsAndSelf()) {
				if (item.ParentNode != null && item.ParentNode.Name == "script") {
				}
				else if (item.NodeType != HtmlAgilityPack.HtmlNodeType.Text) {
				}
				else if (item.InnerText.Trim() != "") {
					chunks.Add(item.InnerText.Trim());
				}
			}

			return String.Join(" ", chunks);
		}
	}
}
