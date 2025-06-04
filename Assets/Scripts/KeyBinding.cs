public class KeyBinding {
    [BsonId]
    public string keyName { get; set; }

    public KeyCode key { get; set; }
}