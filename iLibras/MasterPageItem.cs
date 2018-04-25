using System;

namespace iLibras
{
	public class MasterPageItem
	{
		public string Title { get; set; }
		public string IconSource { get; set; }
		public Type TargetType { get; set; }
        public String Background { get; set; }
        public String Acao { get; set; }
        public int Index { get; set; }
        public bool Visible { get; set; }
	}
}
