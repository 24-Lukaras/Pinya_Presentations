namespace Pinya_Presentations.Models;

public record ChatMessage(
    string Message,
    string Username,
    DateTime SentAtUtc
);

public record ChatMessageViewModel(
    string Message,
    string Username,
    DateTime SentAtUtc,
    bool IsMine
);
