class Story {
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }

        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this story!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error(`You can't like the same story twice!`);
        }

        if (username === this.creator) {
            throw new Error(`You can't like your own story!`);
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this story!");
        }

        this._likes = this._likes.filter(x => x !== username);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        if (id === undefined || !this._comments.some((c) => c.Id == id)) {
            let comment = {
                Id: this._comments.length + 1,
                Username: username,
                Content: content,
                Replies: []
            };

            this._comments.push(comment);
            return `${username} commented on ${this.title}`;
        }

        let currComment = this._comments.find((c) => c.Id == id);
        let reply = {
            Id: `${currComment.Id}.${currComment.Replies.length + 1}`,
            Username: username,
            Content: content
        };

        currComment.Replies.push(reply);
        return `You replied successfully`;
    }

    toString(sortingType) {
        let sortingWay = {
            asc: (a, b) => a.Id - b.Id,
            desc: (a, b) => b.Id - a.Id,
            username: (a, b) => a.Username.localeCompare(b.Username)
        }

        let comments = this._comments.sort(sortingWay[sortingType]);
        comments.forEach(c => c.Replies.sort(sortingWay[sortingType]));

        let commentsString = [];
        for (const comment of comments) {
            let commentString = `-- ${comment.Id}. ${comment.Username}: ${comment.Content}`;
            let replyString = comment.Replies.map(x => `--- ${x.Id}. ${x.Username}: ${x.Content}`).join('\n');

            replyString = comment.Replies.length > 0 ? `\n${replyString}` : '';
            let combinedString = `${commentString}${replyString}`;
            commentsString.push(combinedString);
        }

        let fullCommentsString = this.comment.length > 0 ? `\n${commentsString.join('\n')}` : '';

        return `Title: ${this.title}
Creator: ${this.creator}
Likes: ${this._likes.length}
Comments:${fullCommentsString}`;
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
