// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CommandLine;

namespace Microsoft.CodeAnalysis.Sarif.Multitool
{
    internal static class Program
    {
        /// <summary>The entry point for the SARIF multi utility.</summary>
        /// <param name="args">Arguments passed in from the tool's command line.</param>
        /// <returns>0 on success; nonzero on failure.</returns>
        public static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<
                AbsoluteUriOptions,
                ConvertOptions,
                FileWorkItemsOptions,
                GenerateValidatorDocumentationOptions,
                MergeOptions,
                PageOptions,
                QueryOptions,
                RebaseUriOptions,
                ResultMatchingOptions,
                ResultMatchSetOptions,
                RewriteOptions,
                TransformOptions,
                ValidateOptions>(args)
                .MapResult(
                (AbsoluteUriOptions absoluteUriOptions) => new AbsoluteUriCommand().Run(absoluteUriOptions),
                (ConvertOptions convertOptions) => new ConvertCommand().Run(convertOptions),
                (FileWorkItemsOptions fileWorkItemsOptions) => new FileWorkItemsCommand().Run(fileWorkItemsOptions),
                (GenerateValidatorDocumentationOptions generateValidatorDocumentationOptions) => new GenerateValidatorDocumentationCommand().Run(generateValidatorDocumentationOptions),
                (MergeOptions mergeOptions) => new MergeCommand().Run(mergeOptions),
                (PageOptions pageOptions) => new PageCommand().Run(pageOptions),
                (QueryOptions queryOptions) => new QueryCommand().Run(queryOptions),
                (RebaseUriOptions rebaseOptions) => new RebaseUriCommand().Run(rebaseOptions),
                (ResultMatchingOptions baselineOptions) => new ResultMatchingCommand().Run(baselineOptions),
                (ResultMatchSetOptions options) => new ResultMatchSetCommand().Run(options),
                (RewriteOptions rewriteOptions) => new RewriteCommand().Run(rewriteOptions),
                (TransformOptions transformOptions) => new TransformCommand().Run(transformOptions),
                (ValidateOptions validateOptions) => new ValidateCommand().Run(validateOptions),
                errs => CommandBase.FAILURE);
        }
    }
}
