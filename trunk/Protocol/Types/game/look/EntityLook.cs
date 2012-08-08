// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'EntityLook.xml' the '27/06/2012 15:55:17'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;

namespace BiM.Protocol.Types
{
	public class EntityLook
	{
		public const uint Id = 55;
		public virtual short TypeId
		{
			get
			{
				return 55;
			}
		}
		
		public short bonesId;
		public short[] skins;
		public int[] indexedColors;
		public short[] scales;
		public Types.SubEntity[] subentities;
		
		public EntityLook()
		{
		}
		
		public EntityLook(short bonesId, short[] skins, int[] indexedColors, short[] scales, Types.SubEntity[] subentities)
		{
			this.bonesId = bonesId;
			this.skins = skins;
			this.indexedColors = indexedColors;
			this.scales = scales;
			this.subentities = subentities;
		}
		
		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort(bonesId);
			writer.WriteUShort((ushort)skins.Count());
			foreach (var entry in skins)
			{
				writer.WriteShort(entry);
			}
			writer.WriteUShort((ushort)indexedColors.Count());
			foreach (var entry in indexedColors)
			{
				writer.WriteInt(entry);
			}
			writer.WriteUShort((ushort)scales.Count());
			foreach (var entry in scales)
			{
				writer.WriteShort(entry);
			}
			writer.WriteUShort((ushort)subentities.Count());
			foreach (var entry in subentities)
			{
				entry.Serialize(writer);
			}
		}
		
		public virtual void Deserialize(IDataReader reader)
		{
			bonesId = reader.ReadShort();
			if ( bonesId < 0 )
			{
				throw new Exception("Forbidden value on bonesId = " + bonesId + ", it doesn't respect the following condition : bonesId < 0");
			}
			int limit = reader.ReadUShort();
			skins = new short[limit];
			for (int i = 0; i < limit; i++)
			{
				(skins as short[])[i] = reader.ReadShort();
			}
			limit = reader.ReadUShort();
			indexedColors = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(indexedColors as int[])[i] = reader.ReadInt();
			}
			limit = reader.ReadUShort();
			scales = new short[limit];
			for (int i = 0; i < limit; i++)
			{
				(scales as short[])[i] = reader.ReadShort();
			}
			limit = reader.ReadUShort();
			subentities = new Types.SubEntity[limit];
			for (int i = 0; i < limit; i++)
			{
				(subentities as SubEntity[])[i] = new Types.SubEntity();
				(subentities as Types.SubEntity[])[i].Deserialize(reader);
			}
		}
	}
}
