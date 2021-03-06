﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.DotNet.ImageBuilder.Models.Manifest;

namespace Microsoft.DotNet.ImageBuilder.Tests.Helpers
{
    public static class ManifestHelper
    {
        public static Manifest CreateManifest(params Repo[] repos)
        {
            return new Manifest
            {
                Repos = repos
            };
        }

        public static Repo CreateRepo(string name, params Image[] images)
        {
            return CreateRepo(name, images, mcrTagsMetadataTemplatePath: null);
        }

        public static Repo CreateRepo(string name, Image[] images, string mcrTagsMetadataTemplatePath = null)
        {
            return new Repo
            {
                Name = name,
                Images = images,
                McrTagsMetadataTemplatePath = mcrTagsMetadataTemplatePath
            };
        }

        public static Image CreateImage(params Platform[] platforms) =>
            CreateImage(platforms, (IDictionary<string, Tag>)null);

        public static Image CreateImage(Platform[] platforms, IDictionary<string, Tag> sharedTags = null, string productVersion = null)
        {
            return new Image
            {
                Platforms = platforms,
                SharedTags = sharedTags,
                ProductVersion = productVersion
            };
        }

        public static Platform CreatePlatform(
            string dockerfilePath, string[] tags, OS os = OS.Linux, string osVersion = "disco", Architecture architecture = Architecture.AMD64,
            CustomBuildLegGrouping[] customBuildLegGroupings = null)
        {
            return new Platform
            {
                Dockerfile = dockerfilePath,
                OsVersion = osVersion,
                OS = os,
                Tags = tags.ToDictionary(tag => tag, tag => new Tag()),
                Architecture = architecture,
                CustomBuildLegGrouping = customBuildLegGroupings ?? Array.Empty<CustomBuildLegGrouping>()
            };
        }
    }
}
