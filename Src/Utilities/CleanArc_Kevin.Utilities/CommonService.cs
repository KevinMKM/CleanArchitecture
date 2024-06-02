using CleanArc_Kevin.Core.Abstractions.Caching;
using CleanArc_Kevin.Core.Abstractions.ObjectMappers;
using CleanArc_Kevin.Core.Abstractions.Serializers;
using CleanArc_Kevin.Core.Abstractions.Translations;
using CleanArc_Kevin.Core.Abstractions.UsersManagement;
using Microsoft.Extensions.Logging;

namespace CleanArc_Kevin.Utilities;

public class CommonService
{
    public readonly ITranslator Translator;
    public readonly ICacheAdapter CacheAdapter;
    public readonly IMapperAdapter MapperFacade;
    public readonly ILoggerFactory LoggerFactory;
    public readonly IJsonSerializer Serializer;
    public readonly IUserInfoService UserInfoService;

    public CommonService(ITranslator translator,
        ILoggerFactory loggerFactory,
        IJsonSerializer serializer,
        IUserInfoService userInfoService,
        ICacheAdapter cacheAdapter,
        IMapperAdapter mapperFacade)
    {
        Translator = translator;
        LoggerFactory = loggerFactory;
        Serializer = serializer;
        UserInfoService = userInfoService;
        CacheAdapter = cacheAdapter;
        MapperFacade = mapperFacade;
    }
}