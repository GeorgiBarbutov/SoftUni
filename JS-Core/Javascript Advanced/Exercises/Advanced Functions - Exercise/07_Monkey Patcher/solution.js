function solution(argument){
    let actualUpvotes = this.upvotes;
    let actualDownvotes = this.downvotes;

    if(argument === "upvote"){
        this.upvotes += 1;
    } else if(argument === "downvote") {
        this.downvotes += 1;
    } else if(argument === "score") {
        let balance = actualUpvotes - actualDownvotes;

        let totalVotes = actualUpvotes + actualDownvotes;

        let rating = "";
        if(totalVotes < 10) {
            rating = "new";
        }else if(actualUpvotes / totalVotes > 0.66) {
            rating = "hot";
        } else if(balance >= 0 && (actualDownvotes > 100 || actualUpvotes > 100)) {
            rating = "controversial";
        } else if(balance < 0) {
            rating = "unpopular";
        } else {
            rating = "new";
        }

        let highestVotes = 0;
        if(actualUpvotes - actualDownvotes >= 0) {
            highestVotes = actualUpvotes;
        } else {
            highestVotes = actualDownvotes;
        }

        let reportedUpvotes = actualUpvotes;
        let reportedDownvotes = actualDownvotes;

        if(totalVotes > 50){
            reportedUpvotes += Math.ceil(highestVotes * 0.25);
            reportedDownvotes += Math.ceil(highestVotes * 0.25);
        }

        let reportedBalance = reportedUpvotes - reportedDownvotes;

        return [reportedUpvotes, reportedDownvotes, reportedBalance, rating];
    }
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 0,
    downvotes: 0
};
solution.call(post, 'upvote');
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']
solution.call(post, 'downvote');        // (executed 50 times)
score = solution.call(post, 'score');     // [139, 189, -50, 'unpopular']
