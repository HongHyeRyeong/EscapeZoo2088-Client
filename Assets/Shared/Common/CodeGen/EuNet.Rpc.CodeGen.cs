﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EuNet.CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using EuNet.Core;
using EuNet.Rpc;
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_ANDROID || UNITY_IOS
using EuNet.Unity;
using UnityEngine;
#endif

#region Common.ILoginRpc

namespace Common
{
    public interface ILoginRpc_NoReply
    {
        void GetUserInfo();
        void Join();
        void Login(string id);
    }

    public enum ILoginRpc_Enum : int
    {
        GetUserInfo = -1155460313,
        Join = -1471800254,
        Login = -1327137735,
    }

    public class LoginRpc : RpcRequester, ILoginRpc, ILoginRpc_NoReply
    {
        public override Type InterfaceType => typeof(ILoginRpc);

        public LoginRpc() : base(null)
        {
            DeliveryMethod = DeliveryMethod.Tcp;
        }

        public LoginRpc(ISession target) : base(target)
        {
            DeliveryMethod = DeliveryMethod.Tcp;
        }

        public LoginRpc(ISession target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
            DeliveryMethod = DeliveryMethod.Tcp;
        }

        public ILoginRpc_NoReply WithNoReply()
        {
            return this;
        }

        public LoginRpc WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new LoginRpc(Target, requestWaiter, Timeout);
        }

        public LoginRpc WithTimeout(TimeSpan? timeout)
        {
            return new LoginRpc(Target, RequestWaiter, timeout);
        }

        public async Task<Common.UserInfo> GetUserInfo()
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)ILoginRpc_Enum.GetUserInfo);
                using(var _reader_ = await SendRequestAndReceive(_writer_))
                {
                    return NetDataSerializer.Deserialize<Common.UserInfo>(_reader_);
                }
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }

        public async Task<bool> Join()
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)ILoginRpc_Enum.Join);
                using(var _reader_ = await SendRequestAndReceive(_writer_))
                {
                    return _reader_.ReadBoolean();
                }
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }

        public async Task<int> Login(string id)
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)ILoginRpc_Enum.Login);
                _writer_.Write(id);
                using(var _reader_ = await SendRequestAndReceive(_writer_))
                {
                    return _reader_.ReadInt32();
                }
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }

        void ILoginRpc_NoReply.GetUserInfo()
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)ILoginRpc_Enum.GetUserInfo);
                SendRequest(_writer_);
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }

        void ILoginRpc_NoReply.Join()
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)ILoginRpc_Enum.Join);
                SendRequest(_writer_);
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }

        void ILoginRpc_NoReply.Login(string id)
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)ILoginRpc_Enum.Login);
                _writer_.Write(id);
                SendRequest(_writer_);
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }
    }

    public abstract class LoginRpcServiceAbstract : IRpcInvokable, ILoginRpc
    {
        public abstract Task<Common.UserInfo> GetUserInfo();
        public abstract Task<bool> Join();
        public abstract Task<int> Login(string id);
        public async Task<bool> Invoke(object _target_, NetDataReader _reader_, NetDataWriter _writer_)
        {
            ISession session = _target_ as ISession;
            var typeEnum = (ILoginRpc_Enum)_reader_.ReadInt32();
            switch(typeEnum)
            {
                case ILoginRpc_Enum.GetUserInfo:
                    {
                        var _result_ = await GetUserInfo();
                        NetDataSerializer.Serialize<Common.UserInfo>(_writer_, _result_);
                    }
                    break;
                case ILoginRpc_Enum.Join:
                    {
                        var _result_ = await Join();
                        _writer_.Write(_result_);
                    }
                    break;
                case ILoginRpc_Enum.Login:
                    {
                        var id = _reader_.ReadString();
                        var _result_ = await Login(id);
                        _writer_.Write(_result_);
                    }
                    break;
                default: return false;
            }

            return true;
        }
    }

    public class LoginRpcServiceSession : IRpcInvokable
    {
        public async Task<bool> Invoke(object _target_, NetDataReader _reader_, NetDataWriter _writer_)
        {
            ISession session = _target_ as ISession;
            var typeEnum = (ILoginRpc_Enum)_reader_.ReadInt32();
            switch(typeEnum)
            {
                case ILoginRpc_Enum.GetUserInfo:
                    {
                        var _result_ = await (session as ILoginRpc).GetUserInfo();
                        NetDataSerializer.Serialize<Common.UserInfo>(_writer_, _result_);
                    }
                    break;
                case ILoginRpc_Enum.Join:
                    {
                        var _result_ = await (session as ILoginRpc).Join();
                        _writer_.Write(_result_);
                    }
                    break;
                case ILoginRpc_Enum.Login:
                    {
                        var id = _reader_.ReadString();
                        var _result_ = await (session as ILoginRpc).Login(id);
                        _writer_.Write(_result_);
                    }
                    break;
                default: return false;
            }

            return true;
        }
    }
}

#endregion
#region Common.IShopRpc

namespace Common
{
    public interface IShopRpc_NoReply
    {
        void PurchaseItem(string itemId);
    }

    public enum IShopRpc_Enum : int
    {
        PurchaseItem = -1585425401,
    }

    public class ShopRpc : RpcRequester, IShopRpc, IShopRpc_NoReply
    {
        public override Type InterfaceType => typeof(IShopRpc);

        public ShopRpc() : base(null)
        {
            DeliveryMethod = DeliveryMethod.Tcp;
        }

        public ShopRpc(ISession target) : base(target)
        {
            DeliveryMethod = DeliveryMethod.Tcp;
        }

        public ShopRpc(ISession target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
            DeliveryMethod = DeliveryMethod.Tcp;
        }

        public IShopRpc_NoReply WithNoReply()
        {
            return this;
        }

        public ShopRpc WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new ShopRpc(Target, requestWaiter, Timeout);
        }

        public ShopRpc WithTimeout(TimeSpan? timeout)
        {
            return new ShopRpc(Target, RequestWaiter, timeout);
        }

        public async Task<int> PurchaseItem(string itemId)
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)IShopRpc_Enum.PurchaseItem);
                _writer_.Write(itemId);
                using(var _reader_ = await SendRequestAndReceive(_writer_))
                {
                    return _reader_.ReadInt32();
                }
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }

        void IShopRpc_NoReply.PurchaseItem(string itemId)
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)IShopRpc_Enum.PurchaseItem);
                _writer_.Write(itemId);
                SendRequest(_writer_);
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }
    }

    public abstract class ShopRpcServiceAbstract : IRpcInvokable, IShopRpc
    {
        public abstract Task<int> PurchaseItem(string itemId);
        public async Task<bool> Invoke(object _target_, NetDataReader _reader_, NetDataWriter _writer_)
        {
            ISession session = _target_ as ISession;
            var typeEnum = (IShopRpc_Enum)_reader_.ReadInt32();
            switch(typeEnum)
            {
                case IShopRpc_Enum.PurchaseItem:
                    {
                        var itemId = _reader_.ReadString();
                        var _result_ = await PurchaseItem(itemId);
                        _writer_.Write(_result_);
                    }
                    break;
                default: return false;
            }

            return true;
        }
    }

    public class ShopRpcServiceSession : IRpcInvokable
    {
        public async Task<bool> Invoke(object _target_, NetDataReader _reader_, NetDataWriter _writer_)
        {
            ISession session = _target_ as ISession;
            var typeEnum = (IShopRpc_Enum)_reader_.ReadInt32();
            switch(typeEnum)
            {
                case IShopRpc_Enum.PurchaseItem:
                    {
                        var itemId = _reader_.ReadString();
                        var _result_ = await (session as IShopRpc).PurchaseItem(itemId);
                        _writer_.Write(_result_);
                    }
                    break;
                default: return false;
            }

            return true;
        }
    }
}

#endregion
#region Common.IActorViewRpc
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_ANDROID || UNITY_IOS

namespace Common
{
    public interface IActorViewRpc_NoReply
    {
        void OnSetMoveVelocity(float x, bool jump);
    }

    public enum IActorViewRpc_Enum : int
    {
        OnSetMoveDirection = -2049226282,
    }

    public class ActorViewRpc : RpcRequester, IActorViewRpc, IActorViewRpc_NoReply
    {
        public override Type InterfaceType => typeof(IActorViewRpc);

        public ActorViewRpc(NetView view, TimeSpan? timeout = null)
            	: base(NetClientGlobal.Instance.Client, new NetViewRequestWaiter(view), timeout)
        {
            DeliveryMethod = DeliveryMethod.Unreliable;
            DeliveryTarget = DeliveryTarget.Others;
        }

        public ActorViewRpc(ISession target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
            DeliveryMethod = DeliveryMethod.Unreliable;
            DeliveryTarget = DeliveryTarget.Others;
        }

        public ActorViewRpc ToTarget(DeliveryMethod deliveryMethod, ushort sessionId)
        {
            DeliveryMethod = deliveryMethod;
            DeliveryTarget = DeliveryTarget.Target;
            Extra = sessionId;
            return this;
        }

        public ActorViewRpc ToMaster(DeliveryMethod deliveryMethod)
        {
            DeliveryMethod = deliveryMethod;
            DeliveryTarget = DeliveryTarget.Master;
            return this;
        }

        public IActorViewRpc_NoReply ToOthers(DeliveryMethod deliveryMethod)
        {
            DeliveryMethod = deliveryMethod;
            DeliveryTarget = DeliveryTarget.Others;
            return this;
        }

        public IActorViewRpc_NoReply ToAll(DeliveryMethod deliveryMethod)
        {
            DeliveryMethod = deliveryMethod;
            DeliveryTarget = DeliveryTarget.All;
            return this;
        }

        public IActorViewRpc_NoReply WithNoReply()
        {
            return this;
        }

        public ActorViewRpc WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new ActorViewRpc(Target, requestWaiter, Timeout);
        }

        public ActorViewRpc WithTimeout(TimeSpan? timeout)
        {
            return new ActorViewRpc(Target, RequestWaiter, timeout);
        }

        public async Task OnSetMoveVelocity(float x, bool jump)
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)IActorViewRpc_Enum.OnSetMoveDirection);
                _writer_.Write(x);
                _writer_.Write(jump);
                await SendRequestAndWait(_writer_);
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }

        void IActorViewRpc_NoReply.OnSetMoveVelocity(float x, bool jump)
        {
            var _writer_ = NetPool.DataWriterPool.Alloc();
            try
            {
                _writer_.Write((int)IActorViewRpc_Enum.OnSetMoveDirection);
                _writer_.Write(x);
                _writer_.Write(jump);
                SendRequest(_writer_);
            }
            finally
            {
                NetPool.DataWriterPool.Free(_writer_);
            }
        }
    }

    [RequireComponent(typeof(NetView))]
    public abstract class ActorViewRpcServiceBehaviour : MonoBehaviour, IRpcInvokable, IActorViewRpc
    {
        public abstract Task OnSetMoveVelocity(float x, bool jump);
        public async Task<bool> Invoke(object _target_, NetDataReader _reader_, NetDataWriter _writer_)
        {
            ISession session = _target_ as ISession;
            var typeEnum = (IActorViewRpc_Enum)_reader_.ReadInt32();
            switch(typeEnum)
            {
                case IActorViewRpc_Enum.OnSetMoveDirection:
                    {
                        var x = _reader_.ReadSingle();
                        var jump = _reader_.ReadBoolean();
                        await OnSetMoveVelocity(x, jump);
                    }
                    break;
                default: return false;
            }

            return true;
        }
    }

    public class ActorViewRpcServiceView : IRpcInvokable
    {
        public async Task<bool> Invoke(object _target_, NetDataReader _reader_, NetDataWriter _writer_)
        {
            NetView _view_ = _target_ as NetView;
            var typeEnum = (IActorViewRpc_Enum)_reader_.ReadInt32();
            switch(typeEnum)
            {
                case IActorViewRpc_Enum.OnSetMoveDirection:
                    {
                        var x = _reader_.ReadSingle();
                        var jump = _reader_.ReadBoolean();
                        await _view_.FindRpcHandler<IActorViewRpc>().OnSetMoveVelocity(x, jump);
                    }
                    break;
                default: return false;
            }

            return true;
        }
    }
}

#endif
#endregion
#region Common

namespace Common
{
    public static class RpcEnumHelper
    {
        public static string GetEnumName(int rpcNameHash)
        {
            switch(rpcNameHash)
            {
                case -1155460313: return "ILoginRpc.GetUserInfo";
                case -1471800254: return "ILoginRpc.Join";
                case -1327137735: return "ILoginRpc.Login";
                case -1585425401: return "IShopRpc.PurchaseItem";
                case -2049226282: return "IActorViewRpc.OnSetMoveDirection";
            }

            return string.Empty;
        }
    }
}

#endregion
#region AOT

namespace AOT
{
    public sealed class AotCodeCommon
    {
        private void UsedOnlyForAOTCodeGeneration()
        {
            
            throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
        }
    }
}

#endregion
#region Common.UserInfo

namespace Common
{
    public sealed class UserInfoFormatter : INetDataFormatter<UserInfo>
    {
        public static readonly UserInfoFormatter Instance = new UserInfoFormatter();

        public void Serialize(NetDataWriter _writer_, UserInfo _value_, NetDataSerializerOptions options)
        {
            _writer_.Write(_value_.Name);
        }

        public UserInfo Deserialize(NetDataReader _reader_, NetDataSerializerOptions options)
        {
            var __Name = _reader_.ReadString();

            return new UserInfo() {
                Name = __Name,
            };
        }
    }
}

#endregion
#region CommonResolvers

namespace CommonResolvers
{
    public sealed class GeneratedResolver : INetDataFormatterResolver
    {
        public static readonly GeneratedResolver Instance = new GeneratedResolver();

        private GeneratedResolver()
        {
        }

        public INetDataFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            public static readonly INetDataFormatter<T> Formatter;

            static FormatterCache()
            {
                Formatter = (INetDataFormatter<T>)GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
            }
        }
    }

    internal static class GeneratedResolverGetFormatterHelper
    {
        private static readonly Dictionary<Type, object> FormatterMap = new Dictionary<Type, object>() {
            { typeof(Common.UserInfo) , Common.UserInfoFormatter.Instance },
        };
        internal static object GetFormatter(Type t)
        {
            TypeInfo ti = t.GetTypeInfo();
            if (ti.IsGenericType)
            {
                Type genericType = ti.GetGenericTypeDefinition();
                object formatterType;
                if (FormatterMap.TryGetValue(genericType, out formatterType))
                {
                    return Activator.CreateInstance(((Type)formatterType).MakeGenericType(ti.GenericTypeArguments));
                }
            }

            else
            {
                object formatter;
                if (FormatterMap.TryGetValue(t, out formatter))
                {
                    return formatter;
                }
            }

            return null;
        }
    }
}

#endregion
