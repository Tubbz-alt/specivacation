﻿using System;
using System.Linq.Expressions;
using LinqKit;

namespace SpeciVacation
{
    internal struct OrSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _right = right;
            _left = left;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return _left.IsSatisfiedBy(entity) || _right.IsSatisfiedBy(entity);
        }

        public Expression<Func<T, bool>> ToExpression()
        {
            return _left.ToExpression().Or(_right.ToExpression());
        }
    }
}
