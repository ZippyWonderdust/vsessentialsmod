﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace Vintagestory.GameContent
{
    public class PrecipitationState
    {
        public double Level;
        public double ParticleSize;
        public EnumPrecipitationType Type;
    }

    public class WeatherSystemConfig
    {
        public AssetLocation[] SnowLayerBlockCodes;
        public OrderedDictionary<Block, int> SnowLayerBlocks;
        public WeatherPatternConfig RainOverlayPattern;

        internal void Init(IWorldAccessor world)
        {
            SnowLayerBlocks = new OrderedDictionary<Block, int>();

            int i = 0;
            foreach (var loc in SnowLayerBlockCodes)
            {
                Block block = world.GetBlock(loc);
                if (block == null)
                {
                    world.Logger.Error("config/weather.json: No such block found: '{0}', will ignore.", loc);
                    continue;
                }

                SnowLayerBlocks[block] = i++;
            }
        }
    }

}
