global using System;
global using System.Text;
global using System.Collections.Generic;
global using System.Linq;

global using Microsoft.EntityFrameworkCore;

global using Arfware.ArfBlocks.Core;
global using Arfware.ArfBlocks.Core.Abstractions;
//global using Arfware.ArfBlocks.Test;
//global using Arfware.ArfBlocks.Test.Abstractions;

global using Domain.Entities;
global using Infrastructure.RelationalDB;
global using Infrastructure.Services;
global using Microsoft.AspNetCore.Http;
global using Cmms.Infrastructure.Services;
global using FluentValidation;
global using Domain.Errors;
global using Arfware.ArfBlocks.Core.Exceptions;
global using Arfware.ArfBlocks.Core.Contexts;
global using Arfware.ArfBlocks.Core.RequestResults;
global using Arfware.ArfBlocks.Core.Attributes;
global using Arfware.ArfBlocks.Test.Abstractions;
global using ArfFipaso.Filter.Models;
global using ArfFipaso.Pagination.Models;
global using ArfFipaso.Sorting.Models;
global using ArfFipaso.Filter.Extensions;
global using ArfFipaso.Sorting.Extensions;
global using ArfFipaso.Pagination.Extensions;
global using Infrastructure.Services.TestServices;
global using FluentAssertions;
global using Serilog.Core;

