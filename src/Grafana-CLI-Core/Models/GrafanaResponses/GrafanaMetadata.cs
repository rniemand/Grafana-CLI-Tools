using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GrafanaCli.Core.Models.GrafanaResponses
{
  public class GrafanaMetadata
  {
    [JsonProperty("type"), JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonProperty("canSave"), JsonPropertyName("canSave")]
    public bool CanSave { get; set; }

    [JsonProperty("canEdit"), JsonPropertyName("canEdit")]
    public bool CanEdit { get; set; }

    [JsonProperty("canAdmin"), JsonPropertyName("canAdmin")]
    public bool CanAdmin { get; set; }

    [JsonProperty("canStar"), JsonPropertyName("canStar")]
    public bool CanStar { get; set; }

    [JsonProperty("slug"), JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonProperty("url"), JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonProperty("expires"), JsonPropertyName("expires")]
    public DateTime Expires { get; set; }

    [JsonProperty("created"), JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonProperty("updated"), JsonPropertyName("updated")]
    public DateTime Updated { get; set; }

    [JsonProperty("updatedBy"), JsonPropertyName("updatedBy")]
    public string UpdatedBy { get; set; }

    [JsonProperty("createdBy"), JsonPropertyName("createdBy")]
    public string CreatedBy { get; set; }

    [JsonProperty("version"), JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonProperty("hasAcl"), JsonPropertyName("hasAcl")]
    public bool HasAcl { get; set; }

    [JsonProperty("isFolder"), JsonPropertyName("isFolder")]
    public bool IsFolder { get; set; }

    [JsonProperty("folderId"), JsonPropertyName("folderId")]
    public int FolderId { get; set; }

    [JsonProperty("folderTitle"), JsonPropertyName("folderTitle")]
    public string FolderTitle { get; set; }

    [JsonProperty("folderUrl"), JsonPropertyName("folderUrl")]
    public string FolderUrl { get; set; }

    [JsonProperty("provisioned"), JsonPropertyName("provisioned")]
    public bool Provisioned { get; set; }

    [JsonProperty("provisionedExternalId"), JsonPropertyName("provisionedExternalId")]
    public string ProvisionedExternalId { get; set; }

  }
}