using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Dtos;
using Autofac.Core;
using AutoMapper.Internal.Mappers;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Message.ViewModels;
using System.Linq;
using System.Linq.Expressions;

namespace OptionOneTech.AlertSystem.Web.Extensions
{
    namespace OptionOneTech.AlertSystem.Web.Extensions
    {
        public static class LookupAppServiceExtension
        {
            public static async Task<List<LookupDto<Guid>>> FetchAll(this ILookupAppService<Guid> service)
            {
                var pageSize = 5;
                var totalItemsCount = 0;
                var currentPage = 0;
                var allItems = new List<LookupDto<Guid>>();

                var page = await service.GetLookupAsync(new PagedAndSortedResultRequestDto() { SkipCount = 0, MaxResultCount = pageSize });

                totalItemsCount = (int)page.TotalCount;

                allItems.AddRange(page.Items);

                var totalPages = totalItemsCount / pageSize;
                try
                {
                    while (currentPage < totalPages - 1)
                    {
                        currentPage++;
                        page = await service.GetLookupAsync(new PagedAndSortedResultRequestDto()
                        {
                            SkipCount = currentPage * pageSize,
                            MaxResultCount = pageSize
                        });

                        allItems.AddRange(page.Items);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching lookups: {ex.Message}");
                    return new List<LookupDto<Guid>>();
                }
                return allItems;
                }                                           
            }    
        }
    }

