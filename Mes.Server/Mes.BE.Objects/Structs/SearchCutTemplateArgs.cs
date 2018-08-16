using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchCutTemplateArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? TemplateID;
        public string TemplateCode;
        public string TemplateName;        
	}
}
