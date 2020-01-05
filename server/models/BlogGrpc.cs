// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: blog.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Blog {
  public static partial class BlogService
  {
    static readonly string __ServiceName = "blog.BlogService";

    static readonly grpc::Marshaller<global::Blog.CreateBlogRequest> __Marshaller_blog_CreateBlogRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Blog.CreateBlogRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Blog.CreateBlogResponse> __Marshaller_blog_CreateBlogResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Blog.CreateBlogResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Blog.ReadBlogRequest> __Marshaller_blog_ReadBlogRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Blog.ReadBlogRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Blog.ReadBlogResponse> __Marshaller_blog_ReadBlogResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Blog.ReadBlogResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Blog.CreateBlogRequest, global::Blog.CreateBlogResponse> __Method_CreateBlog = new grpc::Method<global::Blog.CreateBlogRequest, global::Blog.CreateBlogResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateBlog",
        __Marshaller_blog_CreateBlogRequest,
        __Marshaller_blog_CreateBlogResponse);

    static readonly grpc::Method<global::Blog.ReadBlogRequest, global::Blog.ReadBlogResponse> __Method_ReadBlog = new grpc::Method<global::Blog.ReadBlogRequest, global::Blog.ReadBlogResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ReadBlog",
        __Marshaller_blog_ReadBlogRequest,
        __Marshaller_blog_ReadBlogResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Blog.BlogReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of BlogService</summary>
    [grpc::BindServiceMethod(typeof(BlogService), "BindService")]
    public abstract partial class BlogServiceBase
    {
      /// <summary>
      /// Unary 
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Blog.CreateBlogResponse> CreateBlog(global::Blog.CreateBlogRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Blog.ReadBlogResponse> ReadBlog(global::Blog.ReadBlogRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for BlogService</summary>
    public partial class BlogServiceClient : grpc::ClientBase<BlogServiceClient>
    {
      /// <summary>Creates a new client for BlogService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public BlogServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for BlogService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public BlogServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected BlogServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected BlogServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Unary 
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Blog.CreateBlogResponse CreateBlog(global::Blog.CreateBlogRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateBlog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Unary 
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Blog.CreateBlogResponse CreateBlog(global::Blog.CreateBlogRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateBlog, null, options, request);
      }
      /// <summary>
      /// Unary 
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Blog.CreateBlogResponse> CreateBlogAsync(global::Blog.CreateBlogRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateBlogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Unary 
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Blog.CreateBlogResponse> CreateBlogAsync(global::Blog.CreateBlogRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateBlog, null, options, request);
      }
      public virtual global::Blog.ReadBlogResponse ReadBlog(global::Blog.ReadBlogRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ReadBlog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Blog.ReadBlogResponse ReadBlog(global::Blog.ReadBlogRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ReadBlog, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Blog.ReadBlogResponse> ReadBlogAsync(global::Blog.ReadBlogRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ReadBlogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Blog.ReadBlogResponse> ReadBlogAsync(global::Blog.ReadBlogRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ReadBlog, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override BlogServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new BlogServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(BlogServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreateBlog, serviceImpl.CreateBlog)
          .AddMethod(__Method_ReadBlog, serviceImpl.ReadBlog).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, BlogServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreateBlog, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Blog.CreateBlogRequest, global::Blog.CreateBlogResponse>(serviceImpl.CreateBlog));
      serviceBinder.AddMethod(__Method_ReadBlog, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Blog.ReadBlogRequest, global::Blog.ReadBlogResponse>(serviceImpl.ReadBlog));
    }

  }
}
#endregion
