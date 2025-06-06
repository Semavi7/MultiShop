﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"} },
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermisson"} },
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermisson"} },
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermisson"} },
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermisson"} },
            new ApiResource("ResourcePayment"){Scopes={ "PaymentFullPermission" } },
            new ApiResource("ResourceImages"){Scopes={ "ImagesFullPermission" } },
            new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermisson"} },
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermisson"} },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermisson","Full authority for order operations"),
            new ApiScope("CargoFullPermisson","Full authority for cargo operations"),
            new ApiScope("BasketFullPermisson","Full authority for basket operations"),
            new ApiScope("CommentFullPermisson","Full authority for comment operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            new ApiScope("ImagesFullPermission","Full authority for images operations"),
            new ApiScope("OcelotFullPermisson","Full authority for ocelot operations"),
            new ApiScope("MessageFullPermisson","Full authority for message operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CargoFullPermisson", "OcelotFullPermisson", "CommentFullPermisson", "ImagesFullPermission",IdentityServerConstants.LocalApi.ScopeName }
            },

            //Meneger
            new Client
            {
                ClientId = "MultiShopManegerId",
                ClientName = "Multi Shop Maneger User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "OrderFullPermisson", "BasketFullPermisson", "CommentFullPermisson", "OcelotFullPermisson", "PaymentFullPermission", "ImagesFullPermission","DiscountFullPermission","MessageFullPermisson","CargoFullPermisson",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile }
            },

            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermisson","CargoFullPermisson","BasketFullPermisson","OcelotFullPermisson","CommentFullPermisson","PaymentFullPermission","ImagesFullPermission","MessageFullPermisson",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }
        };
    }
}