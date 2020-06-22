// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CommandLine;

namespace Microsoft.CodeAnalysis.Sarif.Multitool
{
    /// <summary>
    /// Options for the 'generate-validator-documentation' command, which creates a Markdown
    /// document that describes the rules used by the 'validate' command.
    /// </summary>
    [Verb("generate-validator-documentation", HelpText = "Generate a Markdown document that describes the rules used by the 'validate' command.")]
    internal class GenerateValidatorDocumentationOptions
    {
        [Option('o',
            "output",
            Required = false,
            Default = "SarifValidationRules.md")]
        public string OutputFilePath { get; set; }

        [Option(
            'f',
            "force",
            Default = false,
            HelpText = "Force overwrite of output file if it exists.")]
        public bool Force { get; set; }
    }
}
