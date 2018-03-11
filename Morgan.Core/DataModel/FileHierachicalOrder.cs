namespace Morgan.Core
{
    /// <summary>
    /// Simple model that holds information about the order of tags that a music file should be based on when organizing
    /// </summary>
    public class FileHierachicalOrder
    {
        public TagType? Level1 { get; set; } = TagType.GENRE;
        public TagType? Level2 { get; set; } = TagType.ARTIST;
        public TagType? Level3 { get; set; } = TagType.ALBUM;

        // Title tag should be last tag
        public TagType FinalTag { get; } = TagType.TITLE;
    }
}
