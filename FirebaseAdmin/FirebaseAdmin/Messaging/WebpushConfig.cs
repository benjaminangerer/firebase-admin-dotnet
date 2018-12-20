// Copyright 2018, Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FirebaseAdmin.Messaging
{
    /// <summary>
    /// Represents the Webpush protocol options that can be included in a <see cref="Message"/>.
    /// </summary>
    public sealed class WebpushConfig
    {
        /// <summary>
        /// Webpush HTTP headers. Refer <see href="https://tools.ietf.org/html/rfc8030#section-5">
        /// Webpush specification</see> for supported headers.
        /// </summary>
        [JsonProperty("headers")]
        public IReadOnlyDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Webpush data fields. When set, overrides any data fields set via
        /// <see cref="Message.Data"/>.
        /// </summary>
        [JsonProperty("data")]
        public IReadOnlyDictionary<string, string> Data { get; set; }

        /// <summary>
        /// The Webpush notification to be included in the message.
        /// </summary>
        [JsonProperty("notification")]
        public WebpushNotification Notification { get; set; }

        /// <summary>
        /// Copies this Webpush config, and validates the content of it to ensure that it can be
        /// serialized into the JSON format expected by the FCM service.
        /// </summary>
        internal WebpushConfig CopyAndValidate()
        {
            return new WebpushConfig()
            {
                Headers = this.Headers?.Copy(),
                Data = this.Data?.Copy(),
                Notification = this.Notification?.CopyAndValidate(),
            };
        }
    }
}