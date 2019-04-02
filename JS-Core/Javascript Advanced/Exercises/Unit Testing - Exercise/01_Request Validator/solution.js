function requestValidator(request){
    let method = request.method;
    let uri = request.uri;
    let version = request.version;
    let message = request.message;

    let invalidMessage = "";

    if(method !== "GET" && method !== "POST" && method !== "CONNECT" && method !== "DELETE"){
        invalidMessage = "Method";    
    } else if(!/^[^ ](\*|[A-Za-z0-9.]+)$/.test(uri) || uri === undefined){
        invalidMessage = "URI";
    } else if(version !== "HTTP/0.9" && version !== "HTTP/1.0" && version !== "HTTP/1.1" && version !== "HTTP/2.0"){
        invalidMessage = "Version";
    } else if(!/^[^<>\\&'"]*$/.test(message) || message === undefined){
        invalidMessage = "Message";
    }

    if(invalidMessage === ""){
        return request;
    } else{
        throw new Error(`Invalid request header: Invalid ${invalidMessage}`)
    }
}

  
  requestValidator({
    method: 'GET',
    uri: 'kkk jjjj',
    version: 'HTTP/0.8',
    message: ''
  });
  