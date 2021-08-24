using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuicySwapper_V2_GetAllCps.Exports
{
	public class HSExport
	{
		// Token: 0x02000040 RID: 64
		public class ImportMap
		{
			// Token: 0x170000C8 RID: 200
			// (get) Token: 0x060001D6 RID: 470 RVA: 0x00003A75 File Offset: 0x00001C75
			// (set) Token: 0x060001D7 RID: 471 RVA: 0x00003A7D File Offset: 0x00001C7D
			public string type { get; set; }

			// Token: 0x170000C9 RID: 201
			// (get) Token: 0x060001D8 RID: 472 RVA: 0x00003A86 File Offset: 0x00001C86
			// (set) Token: 0x060001D9 RID: 473 RVA: 0x00003A8E File Offset: 0x00001C8E
			public object value { get; set; }
		}

		// Token: 0x02000041 RID: 65
		public class ObjectName
		{
			// Token: 0x170000CA RID: 202
			// (get) Token: 0x060001DB RID: 475 RVA: 0x00003A97 File Offset: 0x00001C97
			// (set) Token: 0x060001DC RID: 476 RVA: 0x00003A9F File Offset: 0x00001C9F
			public int index { get; set; }

			// Token: 0x170000CB RID: 203
			// (get) Token: 0x060001DD RID: 477 RVA: 0x00003AA8 File Offset: 0x00001CA8
			// (set) Token: 0x060001DE RID: 478 RVA: 0x00003AB0 File Offset: 0x00001CB0
			public int number { get; set; }
		}

		// Token: 0x02000042 RID: 66
		public class OuterIndex
		{
			// Token: 0x170000CC RID: 204
			// (get) Token: 0x060001E0 RID: 480 RVA: 0x00003AB9 File Offset: 0x00001CB9
			// (set) Token: 0x060001E1 RID: 481 RVA: 0x00003AC1 File Offset: 0x00001CC1
			public string type { get; set; }

			// Token: 0x170000CD RID: 205
			// (get) Token: 0x060001E2 RID: 482 RVA: 0x00003ACA File Offset: 0x00001CCA
			// (set) Token: 0x060001E3 RID: 483 RVA: 0x00003AD2 File Offset: 0x00001CD2
			public long value { get; set; }
		}

		// Token: 0x02000043 RID: 67
		public class ClassIndex
		{
			// Token: 0x170000CE RID: 206
			// (get) Token: 0x060001E5 RID: 485 RVA: 0x00003ADB File Offset: 0x00001CDB
			// (set) Token: 0x060001E6 RID: 486 RVA: 0x00003AE3 File Offset: 0x00001CE3
			public string type { get; set; }

			// Token: 0x170000CF RID: 207
			// (get) Token: 0x060001E7 RID: 487 RVA: 0x00003AEC File Offset: 0x00001CEC
			// (set) Token: 0x060001E8 RID: 488 RVA: 0x00003AF4 File Offset: 0x00001CF4
			public long value { get; set; }
		}

		// Token: 0x02000044 RID: 68
		public class SuperIndex
		{
			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x060001EA RID: 490 RVA: 0x00003AFD File Offset: 0x00001CFD
			// (set) Token: 0x060001EB RID: 491 RVA: 0x00003B05 File Offset: 0x00001D05
			public string type { get; set; }

			// Token: 0x170000D1 RID: 209
			// (get) Token: 0x060001EC RID: 492 RVA: 0x00003B0E File Offset: 0x00001D0E
			// (set) Token: 0x060001ED RID: 493 RVA: 0x00003B16 File Offset: 0x00001D16
			public long value { get; set; }
		}

		// Token: 0x02000045 RID: 69
		public class TemplateIndex
		{
			// Token: 0x170000D2 RID: 210
			// (get) Token: 0x060001EF RID: 495 RVA: 0x00003B1F File Offset: 0x00001D1F
			// (set) Token: 0x060001F0 RID: 496 RVA: 0x00003B27 File Offset: 0x00001D27
			public string type { get; set; }

			// Token: 0x170000D3 RID: 211
			// (get) Token: 0x060001F1 RID: 497 RVA: 0x00003B30 File Offset: 0x00001D30
			// (set) Token: 0x060001F2 RID: 498 RVA: 0x00003B38 File Offset: 0x00001D38
			public long value { get; set; }
		}

		// Token: 0x02000046 RID: 70
		public class GlobalImportIndex
		{
			// Token: 0x170000D4 RID: 212
			// (get) Token: 0x060001F4 RID: 500 RVA: 0x00003B41 File Offset: 0x00001D41
			// (set) Token: 0x060001F5 RID: 501 RVA: 0x00003B49 File Offset: 0x00001D49
			public string type { get; set; }

			// Token: 0x170000D5 RID: 213
			// (get) Token: 0x060001F6 RID: 502 RVA: 0x00003B52 File Offset: 0x00001D52
			// (set) Token: 0x060001F7 RID: 503 RVA: 0x00003B5A File Offset: 0x00001D5A
			public long value { get; set; }
		}

		// Token: 0x02000047 RID: 71
		public class ExportMap
		{
			// Token: 0x170000D6 RID: 214
			// (get) Token: 0x060001F9 RID: 505 RVA: 0x00003B63 File Offset: 0x00001D63
			// (set) Token: 0x060001FA RID: 506 RVA: 0x00003B6B File Offset: 0x00001D6B
			public int cookedSerialOffset { get; set; }

			// Token: 0x170000D7 RID: 215
			// (get) Token: 0x060001FB RID: 507 RVA: 0x00003B74 File Offset: 0x00001D74
			// (set) Token: 0x060001FC RID: 508 RVA: 0x00003B7C File Offset: 0x00001D7C
			public int cookedSerialSize { get; set; }

			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x060001FD RID: 509 RVA: 0x00003B85 File Offset: 0x00001D85
			// (set) Token: 0x060001FE RID: 510 RVA: 0x00003B8D File Offset: 0x00001D8D
			public HSExport.ObjectName objectName { get; set; }

			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x060001FF RID: 511 RVA: 0x00003B96 File Offset: 0x00001D96
			// (set) Token: 0x06000200 RID: 512 RVA: 0x00003B9E File Offset: 0x00001D9E
			public HSExport.OuterIndex outerIndex { get; set; }

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x06000201 RID: 513 RVA: 0x00003BA7 File Offset: 0x00001DA7
			// (set) Token: 0x06000202 RID: 514 RVA: 0x00003BAF File Offset: 0x00001DAF
			public HSExport.ClassIndex classIndex { get; set; }

			// Token: 0x170000DB RID: 219
			// (get) Token: 0x06000203 RID: 515 RVA: 0x00003BB8 File Offset: 0x00001DB8
			// (set) Token: 0x06000204 RID: 516 RVA: 0x00003BC0 File Offset: 0x00001DC0
			public HSExport.SuperIndex superIndex { get; set; }

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x06000205 RID: 517 RVA: 0x00003BC9 File Offset: 0x00001DC9
			// (set) Token: 0x06000206 RID: 518 RVA: 0x00003BD1 File Offset: 0x00001DD1
			public HSExport.TemplateIndex templateIndex { get; set; }

			// Token: 0x170000DD RID: 221
			// (get) Token: 0x06000207 RID: 519 RVA: 0x00003BDA File Offset: 0x00001DDA
			// (set) Token: 0x06000208 RID: 520 RVA: 0x00003BE2 File Offset: 0x00001DE2
			public HSExport.GlobalImportIndex globalImportIndex { get; set; }

			// Token: 0x170000DE RID: 222
			// (get) Token: 0x06000209 RID: 521 RVA: 0x00003BEB File Offset: 0x00001DEB
			// (set) Token: 0x0600020A RID: 522 RVA: 0x00003BF3 File Offset: 0x00001DF3
			public int objectFlags { get; set; }

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x0600020B RID: 523 RVA: 0x00003BFC File Offset: 0x00001DFC
			// (set) Token: 0x0600020C RID: 524 RVA: 0x00003C04 File Offset: 0x00001E04
			public int filterFlags { get; set; }
		}

		// Token: 0x02000048 RID: 72
		public class CharacterPart
		{
			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x0600020E RID: 526 RVA: 0x00003C0D File Offset: 0x00001E0D
			// (set) Token: 0x0600020F RID: 527 RVA: 0x00003C15 File Offset: 0x00001E15
			public string assetPath { get; set; }

			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x06000210 RID: 528 RVA: 0x00003C1E File Offset: 0x00001E1E
			// (set) Token: 0x06000211 RID: 529 RVA: 0x00003C26 File Offset: 0x00001E26
			public string subPath { get; set; }
		}

		// Token: 0x02000049 RID: 73
		public class ExportProperty
		{
			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x06000213 RID: 531 RVA: 0x00003C2F File Offset: 0x00001E2F
			// (set) Token: 0x06000214 RID: 532 RVA: 0x00003C37 File Offset: 0x00001E37
			public string exportType { get; set; }

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x06000215 RID: 533 RVA: 0x00003C40 File Offset: 0x00001E40
			// (set) Token: 0x06000216 RID: 534 RVA: 0x00003C48 File Offset: 0x00001E48
			public List<HSExport.CharacterPart> CharacterParts { get; set; }

			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x06000217 RID: 535 RVA: 0x00003C51 File Offset: 0x00001E51
			// (set) Token: 0x06000218 RID: 536 RVA: 0x00003C59 File Offset: 0x00001E59
			public string AlterationType { get; set; }
		}

		// Token: 0x0200004A RID: 74
		public class Root
		{
			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x0600021A RID: 538 RVA: 0x00003C62 File Offset: 0x00001E62
			// (set) Token: 0x0600021B RID: 539 RVA: 0x00003C6A File Offset: 0x00001E6A
			public List<HSExport.ImportMap> import_map { get; set; }

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x0600021C RID: 540 RVA: 0x00003C73 File Offset: 0x00001E73
			// (set) Token: 0x0600021D RID: 541 RVA: 0x00003C7B File Offset: 0x00001E7B
			public List<HSExport.ExportMap> export_map { get; set; }

			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x0600021E RID: 542 RVA: 0x00003C84 File Offset: 0x00001E84
			// (set) Token: 0x0600021F RID: 543 RVA: 0x00003C8C File Offset: 0x00001E8C
			public List<HSExport.ExportProperty> export_properties { get; set; }
		}
	}
}
