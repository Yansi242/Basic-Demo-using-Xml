﻿using LoginApiDemo.Model.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Service
{
    public abstract class BaseRepository
    {
        public readonly IOptions<DataConfig> _dataConfig;

        protected BaseRepository(IOptions<DataConfig> dataConfig)
        {
            _dataConfig = dataConfig;
        }
    }
}
